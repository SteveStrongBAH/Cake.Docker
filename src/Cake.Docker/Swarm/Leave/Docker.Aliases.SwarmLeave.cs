﻿using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// DockerSwarmLeave alias.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Leaves a swarm using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")] 
        public static void DockerSwarmLeave(this ICakeContext context, params string[] args)
        {
            DockerSwarmLeave(context, new DockerSwarmLeaveSettings(), args);
        }

        /// <summary>
        /// Leaves a swarm given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerSwarmLeave(this ICakeContext context, DockerSwarmLeaveSettings settings, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerSwarmLeaveSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> ();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("swarm leave", settings ?? new DockerSwarmLeaveSettings(), arguments.ToArray());
        }

    }
}
