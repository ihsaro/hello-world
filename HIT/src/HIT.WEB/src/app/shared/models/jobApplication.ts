import { ApplicationPhase } from "../enum/ApplicationPhase";
import { Candidate } from "./candidate";
import { JobPosting } from "./JobPosting";

export interface JobApplication {
    id?: number;
    jobPosting: JobPosting;
    candidate: Candidate;
    matchRate: number;
    applicationPhase: ApplicationPhase;
  }
  
