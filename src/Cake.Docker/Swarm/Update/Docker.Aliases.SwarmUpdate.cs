﻿using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// DockerSwarmUpdate alias.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Updates a swarm using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")] 
        public static void DockerSwarmUpdate(this ICakeContext context, params string[] args)
        {
            DockerSwarmUpdate(context, new DockerSwarmUpdateSettings(), args);
        }

        /// <summary>
        /// Updates a swarm given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerSwarmUpdate(this ICakeContext context, DockerSwarmUpdateSettings settings, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerSwarmUpdateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> ();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("swarm update", settings ?? new DockerSwarmUpdateSettings(), arguments.ToArray());
        }

    }
}
