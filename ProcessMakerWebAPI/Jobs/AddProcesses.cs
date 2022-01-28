using Hangfire;
using ProcessMaker_Data.DataModel;
using ProcessMaker_Data.Randoms;
using ProcessMaker_Data.UoW;
using System;

namespace ProcessMakerWebAPI.Jobs
{
    public class AddProcesses
    {
        private readonly IUnitOfWork unitOfWork;

        //predefined times
        private readonly string CronEvery1Minute = "*/1 * * * *";
        private readonly string CronEvery1MinuteBetween0800and1800 = "* 08-17 * * *";
        private readonly string CronEvery15Minute = "*/15 * * * *";
        private readonly string CronEveryDayAt18 = "00 18 * * *";
        private readonly string CronEveryDayAt2310 = "10 23 * * *";

        public AddProcesses(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            RecurringJob.AddOrUpdate(() => AddRecurringProcess(), CronEvery1MinuteBetween0800and1800, TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate(() => UpdateStatuses(), CronEveryDayAt18, TimeZoneInfo.Local);
        }

        public void AddRecurringProcess()
        {
            //if hour is not between 08:00 and 18:00. Don't make insert.
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 18)
            {
                //get randomword and random int
                RandomWord random = new();
                Random randomInt = new();

                string newWord = random.GetRandomWord();
                int newInt = randomInt.Next(int.MaxValue);

                //i want to know when data is added. this can not be setted by user
                Process_DataModel processDM = new()
                {
                    RandomNumber = newInt,
                    RandomWord = newWord,
                    InsertTime = DateTime.Now,
                    Status = true
                };

                unitOfWork.Processes.Add(processDM);
                unitOfWork.Complete();
            }
        }

        public void UpdateStatuses()
        {
            //we will update previous day's statuses. Our processes works only at between 08-18. Therefore we don't need to compare data with date's hour.
            var processes = unitOfWork.Processes.Where(p => p.InsertTime.Date < DateTime.Now.Date);

            foreach (var process in processes)
            {
                process.Status = false;
            }
            //custom update method call
            unitOfWork.Processes.UpdateGroup(processes);
            unitOfWork.Complete();
        }
    }
}
