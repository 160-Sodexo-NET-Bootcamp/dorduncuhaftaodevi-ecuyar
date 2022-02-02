# Process Maker

This project is the fourth homework that was made for Sodexo .NET Bootcamp.

Main goal is to make operations on a database table with background jobs. Users activate these jobs by using the provided API. Used technologies are `AutoMapper`, `Unit of Work + Repository Pattern`, `Hangfire`.

## Usage

You can download the project and run it with Visual Studio.


## Endpoints

### ➡️ Start Creating and Updating Processes By Using Background Jobs

You can use `https://localhost:44348/api/ProcessMaker/startProcess` and start the jobs. One of the jobs inserts data in `every 15 minutes` to the database when the time is `between 08:00 - 18:00.`
Other job updates record's status property every day at `18:00` from `TRUE` to `FALSE`. To make this insert operation recursive, I used `CRON Expressions`.

### ➡️ Get All Processes

You can use `https://localhost:44348/api/ProcessMaker/all` and see a list of all processes. API return an array like this:
```
[
  {
    "id": 1,
    "randomNumber": 878228649,
    "randomWord": "parallel",
    "insertTime": "2022-01-28T21:54:07.927",
    "status": false
  },
  {
    "id": 2,
    "randomNumber": 1897987683,
    "randomWord": "remarkable",
    "insertTime": "2022-01-28T21:55:07.983",
    "status": false
  }
]
```

### ➡️ Get All Active Processes

You can use `https://localhost:44348/api/ProcessMaker/allActives` and see a list of all active processes like above.

