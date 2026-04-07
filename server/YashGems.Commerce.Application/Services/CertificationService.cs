using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services;

public class CertificationService : ICertificationService
{
    private readonly ICertificationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CertificationService(
        ICertificationRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CertificationDto dto)
    {
        var entity = _mapper.Map<Certification>(dto);

        await _repository.AddAsync(entity);
        await _unitOfWork.CompleteAsync();
    }

    public Task<IEnumerable<CertificationDto>> GetAllAsync()
    {
        var data = _repository.GetAllAsync();
        return _mapper.Map<Task<IEnumerable<CertificationDto>>>(data);
    }

    public Task<CertificationDto?> GetByIdAsync(int id)
    {
        var data = _repository.GetByIdAsync(id);
        return _mapper.Map<Task<CertificationDto?>>(data);
    }

    public async Task UpdateAsync(int id, CertificationDto dto)
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
