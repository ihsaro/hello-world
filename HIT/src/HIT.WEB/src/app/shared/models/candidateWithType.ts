import { CandidateType } from "../enum/CandidateType";

export interface Candidate {
    id?: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    linkedInURL: string;
    candidateType: string;
    candidateLocation: string;
    YearsOfExperience: number;
  }
  
