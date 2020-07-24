using System.Collections.Generic;

namespace TSContaCorrente.Domain.DTOs
{
    public abstract class BaseDTO
    {
        public List<string> Errors { get; set; }

        public BaseDTO()
        {
            Errors = new List<string>();
        }
    }
}
