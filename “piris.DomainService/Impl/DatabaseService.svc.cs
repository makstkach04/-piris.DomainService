﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _piris.DomainService.DbContext
{
    public class DatabaseService : IDatabaseService
    {
        public bool AddPosition(store_positions position)
        {
            //Logger.WriteInfo($"Creating position{position.positionName} "); 


            using (mysql_dbEntities _dbContext = new mysql_dbEntities())
            {
                _dbContext.store_positions.Add(position);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public bool CreateUser(store_users user)
        {
            //Logger.WriteInfo($"Creating user {user.userName}");

            using (mysql_dbEntities _dbContext = new mysql_dbEntities())
            {
                var res = _dbContext.store_users.Where(u =>
u.userName == u.userName).FirstOrDefault();
                if (res == null)
                {
                    store_users dbUsers = new store_users();
                    dbUsers.userName = user.userName;
                    dbUsers.userPassword = user.userPassword;
                    _dbContext.store_users.Add(dbUsers);
                    _dbContext.SaveChanges();
                    return true;
                }
                else { return false; }
            }
        }

        public bool DeletePosition(int id)
        {
            //Logger.WriteInfo($"Trying to delete position {id}");

            using (mysql_dbEntities _dbContext = new mysql_dbEntities())
            {
                var res = _dbContext.store_positions.Where(p =>
p.id == id).FirstOrDefault();
                if (res != null)
                {
                    _dbContext.store_positions.Remove(res);
                    _dbContext.SaveChanges();
                    return true;
                }
                else { return false; }
            }
        }

        public store_positions GetPositionById(int id)
        {
            //Logger.WriteInfo($"Trying to get position {id}");

            using (mysql_dbEntities _dbContext = new mysql_dbEntities())
            {
                var res = _dbContext.store_positions.Where(p => p.id == p.id).FirstOrDefault();
                return res;
            }
        }
        public List<store_positions> GetPositions()
        {
            //Logger.WriteInfo("Trying to get all positions");
            using (mysql_dbEntities _dbContext = new mysql_dbEntities())
            {
                var dbPositions =
_dbContext.store_positions.ToList();
                return dbPositions;
            }
        }

        public store_users GetUserByUserName(string userName)
        {
            //Logger.WriteInfo($"Trying to get user {userName}");

            using (mysql_dbEntities _dbContext = new mysql_dbEntities())
            {
                var dbUser = _dbContext.store_users.Where(u => u.userName == userName).FirstOrDefault();
                if (dbUser != null)
                {
                    return dbUser;
                }
                else { return null; }
            }
        }

        public store_positions UpdatePosition(store_positions
position)
        {
            //Microsoft.Extensions.Logging.Logger.WriteInfo($"Trying to update position { position.positionName}"); 


            using (mysql_dbEntities _dbContext = new mysql_dbEntities())
            {
                var dbPosition = _dbContext.store_positions.Where(p => p.id == position.id).FirstOrDefault();
                if (dbPosition != null)
                {

                    _dbContext.store_positions.AddOrUpdate(position);
                    _dbContext.SaveChanges();
                    return dbPosition;
                }
                else { return null; }
            }
        }
    }
}
