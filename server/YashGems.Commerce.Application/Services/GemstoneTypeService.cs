using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services
{
    public class GemstoneTypeService : IGemstoneTypeService
    {
        private readonly IGemstoneTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GemstoneTypeService(IGemstoneTypeRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GemstoneTypeDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GemstoneTypeDto>>(data);
        }

        public async Task<GemstoneTypeDto?> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return _mapper.Map<GemstoneTypeDto>(data);
        }

        public async Task CreateAsync(GemstoneTypeDto dto)
        {
            var entity = _mapper.Map<GemstoneType>(dto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, GemstoneTypeDto dto)
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
}
