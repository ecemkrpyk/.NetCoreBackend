using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType) //attribute typeları böyle veririz
        {
            //defencive codding-savunma amaçlı
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //aynı type da olmasını sorguluyor
            {
                throw new System.Exception("BU BİR DOĞRULAMA SINIFI DEĞİL");
            }

            _validatorType = validatorType;
        }
        //onbefore ezilecek method
        protected override void OnBefore(IInvocation invocation) //onbefore da bunlar çalışcak
        {
            //reflection: birşeyleri çalışma anında çalıştırmak istersek
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
