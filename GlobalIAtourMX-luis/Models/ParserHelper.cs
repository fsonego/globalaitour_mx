﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalIAtourMX_LUIS.Models;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;

namespace GlobalIAtourMX_LUIS.Models
{
    public static class ParserLuisHelper
    {
        public static string GetDestination(LuisReconizedModel model)
        {
            return model.Entities.city == null ? String.Empty :
                                                            model.Entities.city[0][0];
        }

        public static string GetTicketType(LuisReconizedModel model)
        {
            return model.Entities.ticketType == null ? String.Empty :
                                                            model.Entities.ticketType[0][0];
        }

        public static string GetPaymentMethod(LuisReconizedModel model)
        {
            return model.Entities.paymentMethod == null ? String.Empty :
                                                            model.Entities.paymentMethod[0][0];
        }

        public static DateRange GetDates(LuisReconizedModel model) {

            string finalDate;
            var range = new DateRange();

            if (model.Entities.datetime != null)
            {
                finalDate = model.Entities.datetime[0].Expressions[0].Replace("XXXX", DateTime.Today.Year.ToString());

                range.Start = DateTime.Parse(finalDate.Substring(1, 10));
                range.End = DateTime.Parse(finalDate.Substring(12, 10));
            }
            else {
                range.Start = DateTime.MinValue;
                range.End = DateTime.MinValue;
            }
            
          

            return range;
        }

    }
}
