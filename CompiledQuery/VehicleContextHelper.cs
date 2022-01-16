using CompiledQuery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiledQuery
{
    internal class VehicleContextHelper
    {
        public static Func<VehicleContext, string, Vehicle> GetVehicleByVIN
            = EF.CompileQuery((VehicleContext ctx, string vin) => ctx.Vehicles.Single(v => v.VIN == vin));
    }

    public static class VehicleContextExtensions
    {
        public static Vehicle GetVehicleByVIN(this VehicleContext ctx, string vin)
        {
            return VehicleContextHelper.GetVehicleByVIN(ctx, vin);
        }
    }
}
