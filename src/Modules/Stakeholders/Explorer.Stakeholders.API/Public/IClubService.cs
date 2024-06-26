﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public;

public interface IClubService 
{
    Result<PagedResult<ClubDto>> GetPaged(int page, int pageSize);
    Result<ClubDto> Create(ClubDto club);
    Result<ClubDto> Update(ClubDto club);
    Result<ClubDto> Get(int id);
    Result<ClubDto> Kick(ClubDto club);
    Result<ClubDto> GetClubById(int id);
    Result<List<long>> GetAllMembers(int clubId);
    Result<bool> InviteMembersToTour(long clubId, int senderId, int tourId, List<long> invitedMemberIds);
}
