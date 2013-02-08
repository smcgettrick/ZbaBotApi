using System;
using System.Collections.Generic;
using System.Linq;

namespace ZbaBotApi.Models.Mappers
{
    public class PropertyMapper
    {
        public static List<Property> MapToProperty(List<ZbaBotService.Property> zbaProperties)
        {
            return zbaProperties.Select(zbaProperty => new Property
                {
                    AccountNumber = zbaProperty.AccountNumber, 
                    Address = zbaProperty.Address, Description = zbaProperty.Description, 
                    OwnerName = zbaProperty.OwnerName, 
                    SaleDate = zbaProperty.SaleDate, 
                    SalePrice = zbaProperty.SalePrice, 
                    Value = zbaProperty.Value
                }).ToList();
        }
    }
}