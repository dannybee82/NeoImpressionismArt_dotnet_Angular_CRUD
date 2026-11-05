export interface ControllerAndMethodInterface {
  controller: string,
  method: string
}

import { InjectionToken } from '@angular/core';

export interface ResourceConfig {
  methodGetAll?: ControllerAndMethodInterface;
  methodGetAllById?: ControllerAndMethodInterface;
  methodGetAllByParams?: ControllerAndMethodInterface;
  methodGetAllPagedList?: ControllerAndMethodInterface;
  methodByParams?: ControllerAndMethodInterface;
  methodById?: ControllerAndMethodInterface;
  methodCreate?: ControllerAndMethodInterface;
  methodUpdate?: ControllerAndMethodInterface;
  methodDeleteById?: ControllerAndMethodInterface;
  methodDeleteByParams?: ControllerAndMethodInterface;
}

export const RESOURCE_CONFIG = new InjectionToken<ResourceConfig>('RESOURCE_CONFIG');