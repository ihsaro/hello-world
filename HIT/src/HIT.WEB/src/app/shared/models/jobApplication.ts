import { ApplicationPhase } from "../enum/ApplicationPhase";
import { Candidate } from "./candidate";
import { JobPosting } from "./JobPosting";

export interface JobApplication {
    id?: number;
    JobPosting: JobPosting;
    Candidate: Candidate;
    MatchRate: number;
    applicationPhase: ApplicationPhase;
  }
  
