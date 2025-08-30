using System;
// common between all the models which will derive from BaseEntity
namespace Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
