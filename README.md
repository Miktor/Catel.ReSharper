Catel.ReSharper
===============

Catel.ReSharper is a ReSharper plugin that helps with development in the following
fields:

* Make classes to inherits from ModelBase or ViewModelBase
* Convert automatic properties to Catel properties
* Expose view model properties as view model ones
* Check for arguments using the Argument class

_Basically convert this:_

    /// <summary>
    ///     The person model.
    /// </summary>
    public class Person 
    {
      #region Public Properties

      /// <summary>
      ///     Gets or sets the first name.
      /// </summary>
      public string FirstName { get; set; }
  
      /// <summary>
      ///     Gets or sets the last name.
      /// </summary>
      public string LastName { get; set; }
  
      /// <summary>
      ///     Gets or sets the age.
      /// </summary>
      public int Age { get; set; }
      
      #endregion
    }
    
_into this:_

    /// <summary>
    ///     The person model.
    /// </summary>
    public class Person : ModelBase
    {
        #region Static Fields

        /// <summary>Register the FirstName property so it is known in the class.</summary>
        public static readonly PropertyData FirstNameProperty = RegisterProperty<Person, string>(model => model.FirstName);
        
        /// <summary>Register the LastName property so it is known in the class.</summary>
        public static readonly PropertyData LastNameProperty = RegisterProperty<Person, string>(model => model.LastName, default(string), (s, e) => s.OnLastNameChanged());

        /// <summary>Register the Age property so it is known in the class.</summary>
        public static readonly PropertyData AgeProperty = RegisterProperty<Person, int>(model => model.Age, default(int), (s, e) => s.OnAgeChanged(e));

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string FirstName
        {
            get { return this.GetValue<string>(FirstNameProperty); }
            set { this.SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string LastName
        {
            get { return this.GetValue<string>(LastNameProperty); }
            set { this.SetValue(LastNameProperty, value); }
        }

        /// <summary>
        ///     Gets or sets the age.
        /// </summary>
        public int Age
        {
            get { return this.GetValue<int>(AgeProperty); }
            set { this.SetValue(AgeProperty, value); }
        }

        #endregion
        
        #region Methods
    
        /// <summary>
        /// Occurs when the value of the Age property is changed.
        /// </summary>
        /// <param name="e">
        /// The event argument
        /// </param>
        private void OnAgeChanged(AdvancedPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        ///  Occurs when the value of the LastName property is changed.
        /// </summary>
        private void OnLastNameChanged()
        {
            throw new NotImplementedException();
        }
    
        #endregion
    }
    
_with pleasure!_

For more information about Catel.ReSharper, visit https://github.com/Catel/Catel.ReSharper

## Documentation

Documentation can be found at https://catelproject.atlassian.net/wiki/display/CATELR/

## Issue tracking

The issue tracker including a roadmap can be found at Documentation can be found at https://catelproject.atlassian.net/
