using Domain.Dtos;
using Domain.Entities;
using Domain.Repo;
using Microsoft.Extensions.Configuration;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class ToDoInfoRepo : BaseRepository<ToDoInfo>, IToDoInfoRepo
    {
        public ToDoInfoRepo(AppDbContext datamodel) : base(datamodel) { }
    }
}
