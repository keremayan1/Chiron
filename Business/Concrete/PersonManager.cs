using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public async Task<IDataResult<List<Person>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Person>>(await _personDal.GetAllAsync());
        }

        public async Task<IDataResult<Person>> GetById(int personId)
        {
            return new SuccessDataResult<Person>(await _personDal.GetAsync(p => p.PersonId == personId));
        }

        public async Task<IResult> AddAsync(Person person)
        {
            await _personDal.AddAsync(person);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Person person)
        {
            await _personDal.DeleteAsync(person);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(Person person)
        {
            await _personDal.UpdateAsync(person);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Person>>> GetByName(string name)
        {
            return new SuccessDataResult<List<Person>>(await _personDal.GetAllAsync(p => p.PersonName.ToLower() == name.ToLower()));
        }
    }
}
