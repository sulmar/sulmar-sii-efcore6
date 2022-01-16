using Conversions.Converters;
using Conversions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Conversions
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Profile)
                .HasConversion<JsonConverter<Profile>>();

            //builder.Property(p=>p.Profile)
            //    .HasConversion(
            //        profile => JsonSerializer.Serialize(profile, (JsonSerializerOptions) null),
            //        value => JsonSerializer.Deserialize<Profile>(value, (JsonSerializerOptions) null)
            //    );


            builder.Property(p=>p.Location)
                .HasConversion<GeoHashConverter>();

            builder.Property(p=>p.DateOfBirth)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();

            builder.Property(p=>p.WakeupHour)
                .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();

            builder.Property(p=>p.CanSend)
                .HasConversion(new BoolToStringConverter("No", "Yes"));



        }
    }
}
