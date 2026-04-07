using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services
{
    public class StoneQualityService : IStoneQualityService
    {
        private readonly IStoneQualityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoneQualityService(IStoneQualityRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoneQualityDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StoneQualityDto>>(data);
        }

        public async Task<StoneQualityDto?> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return _mapper.Map<StoneQualityDto>(data);
        }

        public async Task CreateAsync(StoneQualityDto dto)
        {
            var entity = _mapper.Map<StoneQuality>(dto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, StoneQualityDto dto)
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
