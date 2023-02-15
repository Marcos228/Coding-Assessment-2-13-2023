using Coding_Assessment.Classes;
using Coding_Assessment.Controllers;

namespace Coding_Assessment.Services

{
    public class CarServices
    {
        private static List<Car> Cars;
        public CarServices()
        {
            Cars = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
                new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
                new Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
                new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
                new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 }
            };

        }

        public async Task<Car> GetCar(int Id)
        {
            return Cars.FirstOrDefault(x => x.Id == Id);
        }

        public async Task<List<Car>> GetAll()
        {
            return Cars;
        }

        public async Task<bool> UpdateCar(Car updated)
        {
            Car old = Cars.FirstOrDefault(x => x.Id == updated.Id);

            if (old != null)
            {
                old.Make = updated.Make;
                old.Year = updated.Year;
                old.Doors = updated.Doors;
                old.Color = updated.Color;
                old.Price = updated.Price;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async void InsertCar(Car insert)
        {
            if (!Cars.Exists(x=> x.Id == insert.Id))
            {
                Cars.Add(insert);
            }
            return;
        }

        public async Task<bool> DeleteCar(int Id)
        {
            Car old = Cars.FirstOrDefault(x => x.Id == Id);

            if (old != null)
            {
               Cars.Remove(old);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
