using AutoMapper;
using Inspirator.IRepository;
using Inspirator.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Service
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _repository;
        private readonly IMapper _mapper;

        public OptionService(IOptionRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
