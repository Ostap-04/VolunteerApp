using Microsoft.EntityFrameworkCore;
using Volunteer.Dto.Models;

namespace Volunteer.DataAccess.Annotation
{
    internal class GuestAnnotation : BaseEntityAnnotation<Guest>
    {
        internal GuestAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(e => e.Id);
            ModelBuilder.Property(e => e.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            ModelBuilder.Property(e => e.Name).IsRequired().HasMaxLength(30);
        }
    }
}
