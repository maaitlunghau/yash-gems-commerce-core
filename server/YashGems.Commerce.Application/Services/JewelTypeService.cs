using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services;

public class JewelTypeService : IJewelTypeService
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

    async Task<IEnumerable<JewelTypeDto>> IJewelTypeService.GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<JewelTypeDto>>(data);
    }

    async Task<JewelTypeDto?> IJewelTypeService.GetByIdAsync(int id)
    {
        var data = await _repository.GetByIdAsync(id);
        return _mapper.Map<JewelTypeDto?>(data);
    }

    public async Task CreateAsync(JewelTypeDto dto)
    {
        var entity = _mapper.Map<JewelType>(dto);

        await _repository.AddAsync(entity);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, JewelTypeDto dto)
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
