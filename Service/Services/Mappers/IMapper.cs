using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Mappers
{
    public interface IMapper<T, TD>
    {
        T FromDto(TD entity);
        TD ToDto(T entity);
    }
}
