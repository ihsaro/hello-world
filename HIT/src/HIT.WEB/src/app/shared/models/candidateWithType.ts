import { CandidateType } from "../enum/CandidateType";

export interface CandidateWithType {
    id?: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    linkedInURL: string;
    candidateType: string;
    candidateLocation: string;
    YearsOfExperience: number;
    candidateSkills: {
      skill: string,
      id: number
}[]
  }
  
