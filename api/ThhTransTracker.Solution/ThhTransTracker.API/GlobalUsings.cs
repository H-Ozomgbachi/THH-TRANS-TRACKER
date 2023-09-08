﻿global using Serilog;
global using Newtonsoft.Json;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Versioning;
global using ThhTransTracker.API.Extensions;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using ThhTransTracker.Shared.Types;
global using Newtonsoft.Json.Serialization;
global using System.Net;
global using ThhTransTracker.Shared.Exceptions;
global using HealthChecks.UI.Client;
global using ThhTransTracker.API.CustomMiddlewares;
global using ThhTransTracker.Core.Mappers;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using ThhTransTracker.Core.DTOs.Validators;
global using ThhTransTracker.Core.Interfaces.IServices;
global using ThhTransTracker.Core.QueryParams;
global using ThhTransTracker.Infrastructure.Helpers;
global using ThhTransTracker.Core.DTOs;
global using Microsoft.EntityFrameworkCore;
global using ThhTransTracker.Infrastructure.DataContext;
global using ThhTransTracker.Core.Interfaces.IRepositories;
global using ThhTransTracker.Infrastructure.Implementations.Repositories;
global using ThhTransTracker.Infrastructure.Implementations.Services;
global using ThhTransTracker.Core.Entities;
global using System.Security.Claims;
global using Microsoft.AspNetCore.Authorization;
global using ThhTransTracker.Core.Helpers;