﻿using Business.Localization;
using Business.MultiTenancy;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Business
{
    [DependsOn(
        typeof(AbpLocalizationModule)
    )]
    public class BusinessDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BusinessDomainModule>("Business");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<BusinessResource>("zh-Hant")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Business");
            });

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });
        }
    }
}
