using AutoMapper;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services;

public class JewelTypeService : IJewelTypeRepository
{
    private readonly IJewelTypeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public JewelTypeService(
        IJewelTypeRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<JewelType>> GetAllAsync()
    {
        var data = _repository.GetAllAsync();
        return _mapper.Map<Task<IEnumerable<JewelType>>>(data);
    }

    public Task<JewelType?> GetByIdAsync(int id)
    {
        var data = _repository.GetByIdAsync(id);
        return _mapper.Map<Task<JewelType?>>(data);
    }

    public async Task AddAsync(JewelType type)
    {
        var entity = _mapper.Map<JewelType>(type);

        await _repository.AddAsync(entity);
        await _unitOfWork.CompleteAsync();
    }

    public async Task Update(JewelType type)
    {
        var entity = await _repository.GetByIdAsync(type.Id);
        if (entity != null)
        {
            _mapper.Map(type, entity);

            await _repository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task Delete(JewelType type)
    {
        var entity = _mapper.Map<JewelType>(type);
        if (entity != null)
        {
            await _repository.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }
    }
}
