using TaskHouseApi.Persistence.UnitOfWork;
using TaskHouseApi.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskHouseApi.Model;
using System.Linq;
using System;
using TaskHouseUnitTests.FakeRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace TaskHouseUnitTests.UnitTests
{
    public class CategoriesControllerUnitTests
    {
        IUnitOfWork unitOfWork;
        CategoriesController controller;

        public CategoriesControllerUnitTests()
        {
            unitOfWork = new FakeUnitOfWork();
            controller = new CategoriesController(unitOfWork);
        }

        private CategoriesController createContext(CategoriesController con)
        {
            con.ControllerContext = new ControllerContext();
            //Creates a new HttpContext
            con.ControllerContext.HttpContext = new DefaultHttpContext();

            con.ObjectValidator = new DefaultObjectValidator
            (
                new DefaultModelMetadataProvider
                (
                    new DefaultCompositeMetadataDetailsProvider(Enumerable.Empty<IMetadataDetailsProvider>())
                ),
                new List<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>()
            );

            //Returns the controller
            return con;
        }

        //Test retrieve all in repository
        [Fact]
        public void CategoriesController_Get_ReturnAllElementsInRepo_WhenGivenNoParameters()
        {
            var result = controller.Get();
            var resultObjectResult = result as ObjectResult;
            var resultObject = resultObjectResult.Value as IEnumerable<Category>;

            Assert.IsType<ObjectResult>(result);
            Assert.Equal(3, resultObject.Count());
        }

        [Fact]
        //Test GET with id
        public void CategoriesController_Get_ReturnObject_WhenIdIsValid()
        {
            //Arrange id for category object
            int categoryId = 1;

            //Act
            var result = controller.Get(categoryId);
            var resultAsObject = controller.Get(categoryId) as ObjectResult;
            var resultObject = resultAsObject.Value as Category;

            //Assert - Checks if the returned object is the same type and then checks id
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(categoryId, resultObject.Id);
        }

        [Fact]
        // Test GET with invalid ID
        public void CategoriesController_Get_ReturnsNotFound_WhenGivenInvalidId()
        {
            //Arrange id for location object
            int categoryId = 403;

            //Act
            var result = controller.Get(categoryId) as NotFoundResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        //Test POST for creating new category
        public void CategoriesController_Create_ReturnsObject_WhenNewObject()
        {
            controller = createContext(controller);
            //Arrange new ObjectResult
            var category = new Category();
            category.Title = "Title";

            //Act
            var result = controller.Create(category);
            var resultAsObject = result as ObjectResult;
            var resultObject = resultAsObject.Value as Category;

            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(category.Title, resultObject.Title);
        }

        [Fact]
        //Test POST for creating new category that is null
        public void CategoriesController_Create_ReturnsBadRequest_WhenObjectIsNull()
        {
            //Arrange new ObjectResult
            Category category = null;

            //Act
            var result = controller.Create(category);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        // Test PUT for update category
        public void CategoriesController_Update_ReturnsNoContentResultAndCreatedbject_WhenParametersAreValid()
        {
            //Arrange
            Category category = new Category()
            {
                Id = 1,
                Title = "edu1",
                Description = "cate1"
            };
            int id = 1;

            //Act
            var result = controller.Update(id, category);
            var resultAsObject = controller.Get(category.Id) as ObjectResult;
            var resultObject = resultAsObject.Value as Category;

            //Assert
            Assert.IsType<NoContentResult>(result);
            Assert.Equal(category.Title, resultObject.Title);
        }

        ///Test put with invalid Id and null category object
        [Fact]
        public void CategoriesController_Update_ReturnsBadRequestResult_WhencategoryIsNull()
        {
            //Arrange
            Category category = null;
            int id = 0;

            //Act
            var result = controller.Update(id, category);

            //Assert
            Assert.IsType<BadRequestResult>(result);

        }

        [Fact]
        // Test PUT for update category when Id is invalid
        public void CategoriesController_Update_ReturnsBadRequest_WhenIdIsInvalid()
        {
            //Arrange
            Category category = new Category()
            {
                Id = 1,
                Title = "edu1",
                Description = "cate1"
            };
            int id = 100;

            //Act
            var result = controller.Update(id, category);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        // Test DELETE for category
        public void CategoriesController_Delete_ReturnsNoContentResult_WhenDeleted()
        {
            //Arrange
            int Id = 1;

            //Act
            var result = controller.Delete(Id);
            var getDeletedResult = controller.Get(Id);

            //Assert
            Assert.IsType<NoContentResult>(result);
            Assert.IsType<NotFoundResult>(getDeletedResult);
        }

        [Fact]
        //Test DELETE for invalid Id for category
        public void CategoriesController_Delete_ReturnsNotFoundResult_WhenIdInvalid()
        {
            //Arrange
            int Id = 100;

            //Act
            var result = controller.Delete(Id);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }
    }
}
