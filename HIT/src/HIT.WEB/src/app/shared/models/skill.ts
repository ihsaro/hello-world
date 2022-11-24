import { SkillCategoryType } from "../enum/skill-category-type.enum";

export interface Skill {
    id?: number;
    name: string;
    description: string;
    skillCategory: number;
  }
  