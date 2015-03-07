"""
Django settings for zasz project.

"""


# Application basic settings
# ----------------------------------------------------------------------------------

import os
BASE_DIR = os.path.dirname(os.path.dirname(__file__))

# SECURITY WARNING: keep the secret key used in production secret!
SECRET_KEY = 'b_ko$--s5&z%zl91o0tg-jdy#r5+5j0wf9@&p3o%68v7-+2!1t'

# SECURITY WARNING: don't run with debug turned on in production!
DEBUG = True

TEMPLATE_DEBUG = True
TEMPLATE_DIRS = (
    BASE_DIR + '/zasz/templates/',
)
ALLOWED_HOSTS = []


# Application definition
# ----------------------------------------------------------------------------------

INSTALLED_APPS = (
    'django.contrib.admin',
    'django.contrib.auth',
    'django.contrib.contenttypes',
    'django.contrib.sessions',
    'django.contrib.messages',
    'django.contrib.staticfiles',
    'blog',
    "compressor",
)

MIDDLEWARE_CLASSES = (
    'django.contrib.sessions.middleware.SessionMiddleware',
    'django.middleware.common.CommonMiddleware',
    'django.middleware.csrf.CsrfViewMiddleware',
    'django.contrib.auth.middleware.AuthenticationMiddleware',
    'django.contrib.auth.middleware.SessionAuthenticationMiddleware',
    'django.contrib.messages.middleware.MessageMiddleware',
    'django.middleware.clickjacking.XFrameOptionsMiddleware',
)

ROOT_URLCONF = 'zasz.urls'

WSGI_APPLICATION = 'zasz.wsgi.application'


# Database
# ----------------------------------------------------------------------------------

DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.sqlite3',
        'NAME': os.path.join(BASE_DIR, 'db.sqlite3'),
    }
}


# Internationalization
# ----------------------------------------------------------------------------------

LANGUAGE_CODE = 'en-us'

TIME_ZONE = 'IST'

USE_I18N = True

USE_L10N = True

USE_TZ = True


# Static files
# ----------------------------------------------------------------------------------

STATIC_URL = '/static/'

# django.contrib.staticfiles in INSTALLED_APPS uses these finders
STATICFILES_FINDERS = (
    'django.contrib.staticfiles.finders.FileSystemFinder',
    # This finder adds the <app>/static/ folder for all apps installed
    # into this app. Example admin app installed in
    # <python-home>\Lib\site-packages\django\contrib\admin\static\
    # folder
    'django.contrib.staticfiles.finders.AppDirectoriesFinder',
    # This is used by django_compressor
    'compressor.finders.CompressorFinder',
)

STATICFILES_DIRS = (
    # Remove both below, and use front end package manager, and 2 folders for my scripts and styles
    os.path.join(BASE_DIR, "../../../zasz.me/Content/"),
    os.path.join(BASE_DIR, "../../../zasz.me/"),
)

STATIC_ROOT = os.path.join(BASE_DIR, "../zasz_staticfiles/")


# Compressor settings (django_compressor)
# ----------------------------------------------------------------------------------

COMPRESS_ENABLED = False

# Precompile is not dependent on COMPRESS_ENABLED setting. It always precompiles - convenient.
COMPRESS_PRECOMPILERS = (
    # Added c:\ProgramData\chocolatey\lib\nodejs.commandline.0.10.34\tools\ to PATH

    # Depends on "npm install -g coffee-script"
    ('text/coffeescript', 'coffee --compile --stdio'),
    # Depends on "npm install -g less"
    ('text/less', 'lessc {infile}'),
)