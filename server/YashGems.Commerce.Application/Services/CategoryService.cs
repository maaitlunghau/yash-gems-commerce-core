using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(
        ICategoryRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(data);
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var data = await _repository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto?>(data);
    }

    public async Task CreateAsync(CategoryDto dto)
    {
        var entity = _mapper.Map<Category>(dto);

        await _repository.AddAsync(entity);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, CategoryDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            _mapper.Map(dto, entity);

            await _repository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            await _repository.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }
    }
}
