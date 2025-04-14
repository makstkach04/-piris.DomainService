﻿using _piris.DomainService.DbContext;
using _piris.DomainService.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _piris.DomainService
{
    public class PositionService : IPositionService
    {
        private static DatabaseService _databaseService = new
DatabaseService();

        public bool AddPosition(PositionObject position)
        {

            store_positions dbPos = new store_positions();
            dbPos.positionCurrency = position.PositionCurrency;
            dbPos.positionName = position.PositionName;
            dbPos.positionPrice = position.PositionPrice;
            dbPos.positionType = (int)position.PositionType;
            dbPos.positionValue = position.PositionValue;
            dbPos.priceCurrency = position.PriceCurrency;

            _databaseService.AddPosition(dbPos);
            return true;
        }

        public bool DeletePosition(int id)
        {
            var res = _databaseService.DeletePosition(id);
            return res;
        }

        public PositionObject GetPositionById(int id)
        {
            var res = _databaseService.GetPositionById(id);

            PositionObject positionObject = new
PositionObject();
            positionObject.Id = res.id;
            positionObject.PositionCurrency =
res.positionCurrency;
            positionObject.PositionName = res.positionName;
            positionObject.PositionPrice = res.positionPrice;
            positionObject.PositionType =
(PositionType)res.positionType;

            positionObject.PositionValue = res.positionValue;
            positionObject.PriceCurrency = res.priceCurrency;

            return positionObject;
        }

        public List<PositionObject> GetPositions()
        {
            List<PositionObject> positions = new
List<PositionObject>();
            var res = _databaseService.GetPositions();

            foreach (var item in res)
            {
                string positionType = item.positionType;
                positions.Add(new PositionObject
                {
                    Id = item.id,
                    PositionCurrency = item.positionCurrency,
                    PositionName = item.positionName,
                    PositionPrice = item.positionPrice,
                    PositionType =
(PositionType)positionType,
                    PositionValue = item.positionValue,
                    PriceCurrency = item.priceCurrency
                });
            }
            return positions;
        }

        public bool UpdatePosition(PositionObject position)
        {
            store_positions dbPos = new store_positions();
            dbPos.id = position.Id;
            dbPos.positionCurrency = position.PositionCurrency;
            dbPos.positionName = position.PositionName;
            dbPos.positionPrice = position.PositionPrice;
            dbPos.positionType = (int)position.PositionType;
            dbPos.positionValue = position.PositionValue;
            dbPos.priceCurrency = position.PriceCurrency;

            var res = _databaseService.UpdatePosition(dbPos);
            if (res.GetType() != null)
            {
                return true;
            }
            else { return false; }
        }
    }
}
