﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IProfileService
    {
        Result<ProfileDto> Get(int id);
        Result<PagedResult<ProfileDto>> GetPaged(int page, int pageSize);
        Result<ProfileDto> Create(ProfileDto profiles);
        Result<ProfileDto> Update(ProfileDto profiles);

        // PROFILE
        Result<ProfileDto> GetByUserId(int id);
        Result AddFollow(FollowDto follow);
        Result<PagedResult<ProfileDto>> GetAllFollowers(int page, int pageSize, long profileId);
        bool AlreadyFollows(long profileId, long followerId);



        // MESSAGE
        Result<PagedResult<MessageDto>> GetUnreadMessages(int page, int pageSize, long profileId);
    }
}
