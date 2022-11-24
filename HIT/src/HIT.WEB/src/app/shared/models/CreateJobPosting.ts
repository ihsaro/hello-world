import { JobLocation } from "../enum/JobLocation.enum";
import { JobStatus } from "../enum/JobStatus.enum.";
import { JobType } from "../enum/JobType.enum";

export interface CreateJobPosting {
    id?: number;
    title: string;
    description: string;
    yearsOfExperience: number;
    jobLocation: JobLocation;
    jobtype: JobType;
    jobStatus: JobStatus;
    skills: (number|undefined) []
  }
  