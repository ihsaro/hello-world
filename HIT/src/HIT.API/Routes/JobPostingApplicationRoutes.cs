using HIT.API.Routes.Configuration;
using HIT.Domain.Entities;
using HIT.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Net.Mail;

namespace HIT.API.Routes;

public sealed class JobPostingApplicationRoutes : IRoute
{
    public void ConfigureRoutes(WebApplication app)
    {
        app
            .MapGet("api/v1/job-posting-applications/{id}/{phase}", UpdateJobApplicationStatus)
            .AllowAnonymous();
    }

    public async Task<IResult> UpdateJobApplicationStatus(
        int id,
        ApplicationPhase phase,
        [FromServices] IGenericRepository<JobPostingApplication> jobPostingApplicationRepository,
        [FromServices] IGenericRepository<Candidate> candidateRepository
    )
    {
        await candidateRepository.GetAll();
        var jobPostingApplication = await jobPostingApplicationRepository.GetById(id);
        jobPostingApplication.ApplicationPhase = phase;

        await jobPostingApplicationRepository.Update(jobPostingApplication);

        MailMessage message = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        message.From = new MailAddress("idjazh@hotmail.com");
        message.To.Add(new MailAddress(jobPostingApplication.Candidate.EmailAddress));
        message.Subject = "Change in phase";
        message.IsBodyHtml = true; //to make message body as html  
        message.Body = $"Hello, this is to inform you that your application has been changed to {phase}";
        smtp.Port = 587;
        smtp.Host = "smtp-mail.outlook.com"; //for gmail host  
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("idjazh@hotmail.com", "idjaz@saro.com");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(message);

        return Results.Ok(jobPostingApplication);
    }
}
