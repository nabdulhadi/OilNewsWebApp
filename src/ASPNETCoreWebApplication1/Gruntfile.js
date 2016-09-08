/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
  // load Grunt plugins from NPM
  grunt.loadNpmTasks('grunt-contrib-concat');
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-watch');

  // configure plugins
  grunt.initConfig({
    uglify: {
      my_target: {
        files: { 'wwwroot/app.js': ['Scripts/app.js', 'Scripts/**/*.js'] }
      }
    },

    concat: {
      options: {
        separator: ' '
      },

      dist: {
        src: ['Scripts/app.js', 'Scripts/**/*.js'],
        dest: 'wwwroot/app.js'
      }
    },

    watch: {
      scripts: {
        files: ['Scripts/**/*.js'],
        tasks: ['concat']
        //tasks: ['uglify']
      }
    }
  });

  // define tasks
  //grunt.registerTask('default', ['uglify', 'watch']);
  grunt.registerTask('default', ['watch', 'concat']);
};