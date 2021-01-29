﻿using DddDotNet.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DddDotNet.Application
{
    public class DeleteEntityCommand<TEntity> : ICommand
         where TEntity : AggregateRoot<Guid>
    {
        public TEntity Entity { get; set; }
    }

    internal class DeleteEntityCommandHandler<TEntity> : ICommandHandler<DeleteEntityCommand<TEntity>>
    where TEntity : AggregateRoot<Guid>
    {
        private readonly ICrudService<TEntity> _crudService;

        public DeleteEntityCommandHandler(ICrudService<TEntity> crudService)
        {
            _crudService = crudService;
        }

        public async Task HandleAsync(DeleteEntityCommand<TEntity> command, CancellationToken cancellationToken = default)
        {
            await _crudService.DeleteAsync(command.Entity);
        }
    }
}
