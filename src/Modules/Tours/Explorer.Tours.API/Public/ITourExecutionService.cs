﻿using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public
{
    public interface ITourExecutionService
    {
        Result<TourExecutionDto> Update(TourExecutionDto tourExecution);
        Result StartTour(TourExecutionDto dto);
        Result<TourExecutionDto> CompleteTour(int tourExecutionId);
        Result<TourExecutionDto> AbandonTour(int tourExecutionId);
        Result<TourExecutionDto> GetTourExecution (int userId);
       public Result<TourExecutionDto> CompleteCheckpoint(int userId, List<CheckPointDto> checkpoints);
    }
}
