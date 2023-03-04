using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Volunteer.DataAccess.Annotation
{
    public abstract class BaseEntityAnnotation<T>  : IEntityAnnotation
        where T : class
    {
        protected BaseEntityAnnotation(ModelBuilder builder)
        {
            ModelBuilder = builder.Entity<T>();
        }

        protected EntityTypeBuilder<T> ModelBuilder { get; }

        public abstract void Annotate();
    }
}
