using Volunteer.Dto.Models;
using Microsoft.EntityFrameworkCore;

namespace Volunteer.DataAccess.Annotation
{
    internal class RequestAnnotation : BaseEntityAnnotation<Request>
    {
        internal RequestAnnotation(Microsoft.EntityFrameworkCore.ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(e => e.Id);
            ModelBuilder.Property(e => e.Id).ValueGeneratedNever();
            ModelBuilder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            ModelBuilder.Property(e => e.Url).IsRequired().HasMaxLength(300);
            ModelBuilder.Property(e => e.Description).IsRequired().HasMaxLength(999);
            ModelBuilder.Property(e => e.DateOfCreation).IsRequired();
            ModelBuilder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(999);
            ModelBuilder.Property(e => e.Goal).HasColumnType("decimal(18,4)").IsRequired();
            ModelBuilder.Property(e => e.Status).IsRequired();
        }
    }
}
