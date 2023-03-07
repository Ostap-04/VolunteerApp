using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Dto.Models;

namespace Volunteer.DataAccess.Annotation
{
    internal class GuestAnnotation : BaseEntityAnnotation<Guest>
    {
        internal GuestAnnotation(Microsoft.EntityFrameworkCore.ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(e => e.Id);
            ModelBuilder.Property(e => e.Id).ValueGeneratedNever();
            ModelBuilder.Property(e => e.Name).IsRequired().HasMaxLength(30);
        }
    }
}
