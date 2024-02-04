﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Queries.GetAllUser
{
    public class GetAllUserQuery: IGetAllUserQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllUserQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserModel>> Execute()
        {
            var entityList = await _dataBaseService.User.ToListAsync();

            List<GetAllUserModel> modelList = _mapper.Map<List<GetAllUserModel>>(entityList);

            return modelList;
        }
    }
}
