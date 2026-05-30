using _11507_24.Homework._23._05._2026.DTOs;
using _11507_24.Homework._23._05._2026.Utils.MyMapper;
using _11507_24.Homework._23._05._2026.Utils.Validators.Abstraction;

namespace _11507_24.Homework._23._05._2026.Services;

public class BulkProcessor
{
    private readonly IValidator _validator;
    private readonly IMapper _mapper;
    
    // Зависимости внедряются через конструктор (DI)
    public BulkProcessor(IValidator validator, IMapper mapper)
    {
        _validator = validator;
        _mapper = mapper;
    }
    
    public List<UserDto> ProcessParallel(List<object> rawItems, out List<string> allErrors)
    {
        var validDtos = new List<UserDto>();
        var errors = new List<string>();

        // TODO: Распараллелить через Parallel.ForEach
        Parallel.ForEach(rawItems, item =>
        {
           // TODO: Валидация
           if (_validator.Validate(item, out var error))
           {
               var dto = new UserDto();
               
               _mapper.Map(item, dto);
               
               validDtos.Add(dto);
           }
           else
           {
               foreach (var errorItem in error)
               {
                   errors.Add($"[Ошибка валидации] -  {errorItem}");
               }
           }
        });

        allErrors = errors;
        return validDtos;
    }
}