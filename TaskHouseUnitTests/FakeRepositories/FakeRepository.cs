using System.Collections.Generic;
using TaskHouseApi.Model;
using TaskHouseApi.Persistence.Repositories.Interfaces;
using System.Linq;
using System.Reflection;
using System.Collections;

namespace TaskHouseUnitTests.FakeRepositories
{
    public class FakeRepository<T> : IRepository<T> where T : BaseModel
    {
        protected internal List<T> list;

        public FakeRepository(List<T> list)
        {
            this.list = list;
        }

        public void Create(T baseModel)
        {
            list.Add(baseModel);
        }

        public void Delete(T baseModel)
        {
            list.Remove(baseModel);
        }

        public void Delete(int Id)
        {
            T temp = Retrieve(Id);
            list.Remove(temp);
        }

        public bool isInDatabase(int Id)
        {
            return list.Any(o => o.Id == Id);
        }

        public T Retrieve(int Id)
        {
            return list.Where(t => t.Id == Id).SingleOrDefault();
        }

        public virtual IEnumerable<T> RetrieveAll()
        {
            return list;
        }

        public void Update(T baseModel)
        {
            T old = Retrieve(baseModel.Id);
            int index = list.IndexOf(old);

            list[index] = baseModel;
        }

        public void UpdatePart(T baseModel)
        {
            T oldModel = Retrieve(baseModel.Id);
            int index = list.IndexOf(oldModel);

            PropertyInfo[] propertyInfos = baseModel.GetType().GetProperties();
            if (propertyInfos.Count() == 0)
            {
                return;
            }

            foreach (PropertyInfo property in propertyInfos)
            {
                /// If the as ICollection or name is Id do nothing
                if (property.GetValue(baseModel) is ICollection || property.Name == "Id")
                {
                    continue;
                }

                /// Gets the property value
                var propertyValue = property.GetValue(baseModel);

                /// If property name is in ignore is don't change the value
                if (
                        (
                            baseModel.nameOfPropertysToIgnore != null &&
                            baseModel.nameOfPropertysToIgnore.Contains(property.Name)
                        ) ||
                        propertyValue == null)
                {
                    continue;
                }

                /// Marks the property as modified
                oldModel.GetType().GetProperty(property.Name).SetValue(oldModel, propertyValue);
            }

            if (index != -1)
            {
                list[index] = oldModel;
            }
        }
    }
}
