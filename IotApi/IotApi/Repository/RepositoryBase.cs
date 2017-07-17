using IotApi.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IotApi.Repository
{
   
    public class RepositoryBase
    {

        private readonly MoviesDBDataContext _moviesdbDataContext;

        protected MoviesDBDataContext DataContext { get; set; }

        public RepositoryBase(MoviesDBDataContext context)
        {
            DataContext = context;
        }
    }
}