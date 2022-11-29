import { CandidateType } from "../enum/CandidateType";

export interface Candidate {
    id?: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    linkedInURL: string;
    candidateType: CandidateType;
    candidateLocation: string;
    yearsOfExperience: number;
    candidateSkills: {
          skill: string,
          id: number
    }[]
  }
  
