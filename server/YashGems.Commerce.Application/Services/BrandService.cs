using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BrandService(
        IBrandRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BrandDto>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<BrandDto>>(data);
    }

    public async Task<BrandDto?> GetByIdAsync(int id)
    {
        var data = await _repository.GetByIdAsync(id);
        return _mapper.Map<BrandDto?>(data);
    }

    public async Task CreateAsync(BrandDto dto)
    {
        var entity = _mapper.Map<Brand>(dto);

        await _repository.AddAsync(entity);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, BrandDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            _mapper.Map(dto, entity);

            await _repository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        await _repository.Delete(entity);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}
