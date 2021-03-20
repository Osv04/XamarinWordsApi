using Api_Implement.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api_Implement.Service
{
    public interface IWordCategoryService
    {
      Task<Category> GetCategory(string word);   
    }
}
