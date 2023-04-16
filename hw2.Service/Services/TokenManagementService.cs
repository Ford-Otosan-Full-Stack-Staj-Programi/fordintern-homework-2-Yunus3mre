using hw2.Core.Jwt;
using hw2.Core.Models;
using hw2.Core.Repositories;
using hw2.Core.Services;
using hw2.Core.Token;
using hw2.Core.UnitOfWork;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Service.Services
{
    public class TokenManagementService : ITokenManagementService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Account> genericRepo;
     
        private readonly JwtConfig jwtConfig;
        public TokenManagementService(IUnitOfWork unitOfWork, IGenericRepository<Account> genericRepo,  IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.unitOfWork = unitOfWork;
            this.genericRepo = genericRepo;
           
            this.jwtConfig = jwtConfig.CurrentValue;
        }
        public TokenResponse GenerateToken(TokenRequest tokenRequest)
        {
            var account = genericRepo.Where(x => x.UserName == tokenRequest.UserName).FirstOrDefault();
            if (account is null)
            {
                return new TokenResponse();
            }
            if (account.Password != tokenRequest.Password)
            {
                return new TokenResponse();
            }

            string token = GenerateAccessToken(account, DateTime.Now);
            account.LastActivity = DateTime.UtcNow;
            genericRepo.Update(account);
            unitOfWork.Commit();
            TokenResponse response = new TokenResponse
            {
                AccessToken = token,
                ExpireTime = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                Role = account.Role,
                UserName = account.UserName
            };
            return response;

        }
        private string GenerateAccessToken(Account account, DateTime now)
        {
            Claim[] claims = GetClaim(account);
            //claims'ler key-value çiftlerinden oluşur ve token'ın payload kısmını(mesela kullanıcı bilgilerini)
            //içeren kısmını oluşturur.

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }
        private static Claim[] GetClaim(Account account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("Name", account.UserName),
                new Claim("Role", account.Role),
                new Claim("Email", account.Email),
                new Claim("AccountId", account.Id.ToString()),
                new Claim("LastActivity", account.LastActivity.ToLongTimeString())
            };

            return claims;
        }


    }
}
