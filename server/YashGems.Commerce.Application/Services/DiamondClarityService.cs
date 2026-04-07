using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Domain.Entities;
using YashGems.Commerce.Domain.Repositories;

namespace YashGems.Commerce.Application.Services
{
    public class DiamondClarityService : IDiamondClarityService
    {
        private readonly IDiamondClarityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiamondClarityService(IDiamondClarityRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiamondClarityDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DiamondClarityDto>>(data);
        }

        public async Task<DiamondClarityDto?> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return _mapper.Map<DiamondClarityDto>(data);
        }

        public async Task CreateAsync(DiamondClarityDto dto)
        {
            var entity = _mapper.Map<DiamondClarity>(dto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, DiamondClarityDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                _mapper.Map(dto, entity);
                _repository.Update(entity);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            _repository.Delete(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
