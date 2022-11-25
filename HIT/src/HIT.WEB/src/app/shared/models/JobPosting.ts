import { JobLocation } from "../enum/JobLocation.enum";
import { JobStatus } from "../enum/JobStatus.enum.";
import { JobType } from "../enum/JobType.enum";
import { Skill } from "./skill";

export interface JobPosting {
    id?: number;
    title: string;
    description: string;
    yearsOfExperience: number;
    jobLocation: JobLocation;
    jobType: JobType;
    jobStatus: JobStatus;
    jobSkills?: Skill[]
  }
  
