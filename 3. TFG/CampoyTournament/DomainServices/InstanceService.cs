using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository;
using DomainEntities;

namespace DomainServices
{
    /// <summary>
    /// This Class implement Object Instantiation Pattern.
    /// It is used to create concrete objects through an abstract object.
    /// </summary>
    public class InstanceService
    {
        /// <summary>
        /// Static Method to create a new instance for a Service
        /// </summary>
        /// <param name="instanceType"></param>
        /// <returns></returns>
        public static object CreateInstanceRepository(string instanceType)
        {            
            object myRepository;
            switch (instanceType)
            {
                case "TournamentRepository": myRepository = new TournamentRepository(); break;
                case "ResultRepository": myRepository = new ResultRepository(); break;
                case "PlayerRepository": myRepository = new PlayerRepository(); break;
                case "UserRepository": myRepository = new UserRepository(); break;
                case "MatchRepository": myRepository = new MatchRepository(); break;
                case "HoleRepository": myRepository = new HoleRepository(); break;
                case "FieldRepository": myRepository = new FieldRepository(); break;
                case "RoleRepository": myRepository = new RoleRepository(); break;
                default:
                    throw new ArgumentNullException("InstanceService");
            }
            return myRepository;
        }
    }
}