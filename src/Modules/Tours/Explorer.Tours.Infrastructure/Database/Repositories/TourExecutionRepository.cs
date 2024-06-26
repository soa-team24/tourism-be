﻿using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourExecutionRepository : ITourExecutionRepository
    {
        private readonly ToursContext _dbContext;
        public TourExecutionRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TourExecution Get(long id)
        {
            return _dbContext.TourExecutions.Find(id);
        }

        public TourExecution Create(TourExecution entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TourExecution Update(TourExecution entity)
        {
            try
            {
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return entity;
        }

        public TourExecution GetTourExecutionForTourist(int tourId, int touristId)
        {
            return _dbContext.TourExecutions
                .FirstOrDefault(te => te.TourId == tourId && te.TouristId == touristId);
        }

        public List<TourExecution> GetExecutedToursByTourAndUserId(int tourId, int userId)
        {
            return _dbContext.TourExecutions
               .Where(te => te.TourId == tourId && te.TouristId == userId)
               .ToList();
        }


        public List<TourExecution> GetActiveExecutedToursByTourIds(List<long> tourIds)
        {
            return _dbContext.TourExecutions
                .Where(te => tourIds.Contains(te.TourId) && !te.Completed && !te.Abandoned)
                .ToList();
        }



        public List<TourExecution> GetCompletedToursByTourist(int touristId)
        {
            return _dbContext.TourExecutions
                .Where(te => te.TouristId == touristId && te.Completed == true)
                .ToList();
        }

    }
}
